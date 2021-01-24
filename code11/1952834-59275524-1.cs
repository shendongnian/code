    private static void RemoveEmptyWForms(string filePath, string vN, string rPN) {
            XDocument xml = XDocument.Load(filePath);
            List<wForm> listWForms = new List<wForm>();
            List<Elements> listElements = new List<Elements>();
            if (xml.Descendants("vElement").Count() == 0)
            {
                Console.WriteLine("File does not contains elements of type \"vElement\"!");
                return;
            }
            else
            {
                foreach (XElement xe in xml.Descendants("vElement"))
                {
                    Elements el = new Elements();
                    el.PNV = rPN + " | " + vN;
                    el.Node = xe;
                    el.Value = xe.Attribute("number").Value;
                    listElements.Add(el);
                }
            }
            foreach (XElement xw in xml.Descendants("wForm"))
            {
                string value = xw.Attribute("number").Value;
                wForm wfn = new wForm();
                wfn.PNV = rPN + " | " + vN;
                wfn.Node = xw;
                wfn.Value = value;
                if (xw.Descendants("kB").Count() > 0)
                {
                    wfn.CanBeDeleted = false;
                    listWForms.Add(wfn);
                    continue;
                }
                wfn.CanBeDeleted = true;
                listWForms.Add(wfn);
                foreach (XElement xe in xml.Descendants("vElement")) {
                    if (xe.Descendants("elB").Count() > 0)
                    {
                        foreach (Elements el in listElements)
                        {
                            if (el.Node != xe) continue;
                            else { 
                                el.CanBeDeleted = false;
                                break;
                            }
                        }
                    }
                    else {
                        string xeWfn = xe.Element("block").Element("wFormNum").Value;
                        foreach (wForm wf in listWForms) {
                            if (wf.Value.Equals(xeWfn))
                            {
                                if (wf.CanBeDeleted == false) 
                                {
                                    foreach (Elements el in listElements)
                                    {
                                        if (el.Node != xe) continue;
                                        else
                                        {
                                            el.CanBeDeleted = false;
                                            break;
                                        }
                                    }
                                    break;
                                }
                                foreach (Elements el in listElements)
                                {
                                    if (el.Node != xe) continue;
                                    else
                                    {
                                        el.CanBeDeleted = true;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            foreach (wForm wf in listWForms) {
                if (wf.CanBeDeleted) { 
                    wf.Node.Remove();
                    Console.WriteLine("Removing wForm {0} from v {1}", wf.Value, wf.PNV);
                }
            }
            foreach (Elements el in listElements) {
                if (el.CanBeDeleted) { 
                    el.Node.Remove();
                    Console.WriteLine("Removing element {0} from v {1}", el.Value, el.PNV);
                }
            }
        }
			
	class WaveForm { 
        public string PNV { get; set; }
        public XNode Node { get; set; }
        public string Value { get; set; }
        public bool CanBeDeleted { get; set; } = true;
    }
    class Elements {
        public string PNV{ get; set; }
        public XNode Node { get; set; }
        public string Value { get; set; }
        public bool CanBeDeleted { get; set; } = true;
    }
