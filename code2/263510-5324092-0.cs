    public static bool WriteToXMLFile(string fullFileNameWithPath, Object obj, Type ObjectType)
        {
            TextWriter xr = null;
            try
            {
                XmlSerializer ser = new XmlSerializer(ObjectType);
                xr = new StreamWriter(fullFileNameWithPath);
                ser.Serialize(xr, obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if(xr != null)
                    xr.Close();
            }
            return true;
        }
