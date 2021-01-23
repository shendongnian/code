    public class WebWizForumVersion
    {
        public WebWizForumVersion(XmlReader Data)
        {
            this.Software = Data.ReadString("Software");
            this.Version = Data.ReadString("Version");
            this.APIVersion = Data.ReadString("ApiVersion");
            this.NewsPad = Data.ReadBool("NewsPad");
        }
    }
    public static class XmlReaderHelpers
    {
        private string ReadString(this XmlReader Data, string name)
        {
            Data.ReadToFollowing(name);
            return Data.ReadElementContentAsString();
        }
    
        private bool ReadBool(this XmlReader Data, string name)
        {
            return bool.Parse(Data.ReadString(name));
        }
    }
