            var xmlstr = @"<Vehicle>  <CheckPoints ID=""11"">    <Days Day=""1"">check</Days>  </CheckPoints>  <CheckPoints ID=""11"">    <Days Day=""2"">check</Days>  </CheckPoints><CheckPoints ID=""10"">    <Days Day=""1"">check</Days>  </CheckPoints></Vehicle>";
            var id=11;
            var currDay = DateTime.Now.Day;
            var xl = XElement.Load(new StringReader(xmlstr));
            var resxml = from el in xl.Descendants("CheckPoints")
                         where Convert.ToInt32(el.Attribute("ID").Value) == id
                         select el into x
                         from ell in x.Descendants("Days")
                         where Convert.ToInt32(ell.Attribute("Day").Value) <= currDay
                         select ell;
            foreach (var xres in resxml)
            {
                Console.Write(xres.Value);
            }
