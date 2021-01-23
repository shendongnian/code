    public void GetSettings()
        {
            string fileName = "./Names.xml";
            if (File.Exists(fileName))
            {
                XmlTextReader xml = new XmlTextReader(fileName);
                while (xml.Read())
                {
                    if (xml.Name.Equals("pgsql"))
                    {
                        try
                        {
                            button2.Text = xml.GetAttribute("button2");
                            button3.Text = xml.GetAttribute("button3");
                            button4.Text = xml.GetAttribute("button4");
                            button5.Text = xml.GetAttribute("button5");
                        }
                        catch (Exception)
                        {
                            throw new Exception("Settings: Failed to get all settings");
                        }
                    }
                }
            }
            else
            {
                throw new Exception("Settings: pgsql.xml not found!");
            }
        }
