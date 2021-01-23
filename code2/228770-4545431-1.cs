public ElectricScheme LoadScheme(int schemeId)
        {
            var eScheme = (from s in container.ElectricSchemesSet
                            where s.IdElectricScheme.Equals(schemeId)
                            select s).FirstOrDefault();
            if (eScheme == null)
            {
                return null;
            }
            TaskFactory tf = new TaskFactory();
            Elements[] elems = null;
            IGrouping<int, Pins>[] pins = null;
            List<Element> mElements = null;
            var loadElements = tf.StartNew(() =>
                                           elems = (from e in container.Elements
                                                    where e.ElectricSchemes.IdElectricScheme.Equals(schemeId)
                                                    select e).ToArray());
           
            var loadPins = tf.StartNew(() =>
                                       pins = (from p in container.Pins
                                               where p.ElectricSchemesIdElectricScheme.Equals(schemeId)
                                               select p)
											   .GroupBy(x => x.ElementsIdElement).ToArray());
            var buildElements = tf.ContinueWhenAll(
                new Task[] {loadElements, loadPins},
                delegate { mElements = Builder.BuildElement(elems, pins); });
            
            Nets[] net = null;
            IGrouping<int, NetConnections>[] nConn = null;
            List<Net> mNet = null;
            var loadNet =tf.StartNew(() =>
                        net = (from n in container.Nets
                               where n.ElectricSchemes.IdElectricScheme.Equals(schemeId)
                               select n).ToArray());
            var loadConn = tf.StartNew(() =>
                        nConn = (from c in container.NetConnections
                                 where c.ElectricScheme.IdElectricScheme.Equals(schemeId)
                                 select c)
								 .GroupBy(x => x.NetsIdNet).ToArray());
            var buildNet = tf.ContinueWhenAll(
                new Task[] {loadNet, loadConn},
                delegate { mNet = Builder.BuildNet(net, nConn); });
            ElectricScheme scheme = null;
            var buildScheme = tf.ContinueWhenAll(new Task[] {buildElements, buildNet},
                               delegate { scheme = Builder.BuildScheme(mNet, mElements, eScheme.IdElectricScheme); });
            buildScheme.Wait();
            return scheme;
        }
</pre>	
