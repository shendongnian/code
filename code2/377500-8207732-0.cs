       static void Main(string[] args)
        {
            string xmlStr = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><Creators><Creator Role=\"Composer\">Gioachino Rossini</Creator><Creator Role=\"Conductor\">Riccardo Chailly</Creator><Creator Role=\"Orchestra\">National Philharmonic Orchestra</Creator></Creators>";
            using (XmlReader xmlReader = XmlTextReader.Create(new StringReader(xmlStr)))
            {
                xmlReader.MoveToContent();
                xmlReader.ReadStartElement("Creators" , "");
                SomeMethod("Composer", xmlReader);
                SomeMethod("Conductor", xmlReader);
                SomeMethod("Orchestra", xmlReader);
            }
              
            Console.WriteLine("........");
            Console.Read();
        }
        static void SomeMethod(string role, XmlReader xmlReader)
        {
            xmlReader.MoveToAttribute("Role");
            switch (role)
            {
                case "Composer":
                    {
                        xmlReader.MoveToContent();
                        Console.WriteLine(string.Format("Composer:{0}", xmlReader.ReadElementContentAsString()));
                    } break;
                case "Conductor":
                    {
                        xmlReader.MoveToContent();
                        Console.WriteLine(string.Format("Conductor:{0}", xmlReader.ReadElementContentAsString()));
                    } break;
                case "Orchestra":
                    {
                        xmlReader.MoveToContent();
                        Console.WriteLine(string.Format("Orchestra:{0}", xmlReader.ReadElementContentAsString()));
                    } break;
                default: break;
            }
        }
