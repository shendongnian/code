     internal static bool UpdateSubscriberList(MailingListEmail subscriber)
        {
            PropertyInfo[] propertyinfo;
            propertyinfo = typeof(MailingListEmail).GetProperties();
            var values = string.Empty;
            try
            {
                string fileName = @"C:\Development\test.csv";
                if (!File.Exists(fileName))
                {
                    var header = string.Empty;
                    foreach (var prop in propertyinfo)
                    {
                        if (string.IsNullOrEmpty(header))
                            header += prop.Name;
                        else
                            header = string.Format("{0},{1}", header, prop.Name);
                    }
                    header = string.Format("{0},{1}", header, "CreatedDate");
                    header += Environment.NewLine;
                    File.WriteAllText(fileName, header);
                }
               
                    foreach (var prop in propertyinfo)
                    {
                        var value = prop.GetValue(subscriber, null);
                        if (string.IsNullOrEmpty(values))
                            values += value;
                        else
                            values = string.Format("{0},{1}", values, value);
                    }
                    values = string.Format("{0},{1}", values, DateTime.Now.ToShortDateString());
                    values += Environment.NewLine;
                    File.AppendAllText(fileName, values);
                
            }
            catch (Exception ex)
            {
                Elmah.ErrorSignal.FromCurrentContext().Raise(ex);
                return false;
            }
            return true;
        }
