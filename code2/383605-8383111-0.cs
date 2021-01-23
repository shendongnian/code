    using System;
    using System.IO;
    using System.Xml.Serialization;
    static class Program
    {
        static void Main()
        {
            MH_CategoriesTree root = new MH_CategoriesTree(), clone;
            root.response = new MH_CategoriesTreeResponse();
            root.response.type = "alpha";
            root.response.cat = new category
            {
                cat = new category
                {
                    cat = new category
                    {
                        channel = new categoryChannel[]
                        {
                           new categoryChannel { id = 123, idSpecified = true }
                        }
                    },
                    channel = new categoryChannel [0]
                },
                channel = new categoryChannel[]
                {
                    new categoryChannel { id = 456, idSpecified = true},
                    new categoryChannel { id = 789, idSpecified = true },
                }
            };
    
            var ser = new XmlSerializer(typeof(MH_CategoriesTree));
            string xml;
            using(var sw = new StringWriter())
            {
                ser.Serialize(sw, root);
                xml = sw.ToString();
            }
            using(var sr = new StringReader(xml))
            {
                clone = (MH_CategoriesTree) ser.Deserialize(sr);
            }
            // now write "clone" to Console, to show it all worked
            ser.Serialize(Console.Out, clone);
        }
    }
