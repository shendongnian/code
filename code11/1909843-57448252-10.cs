    using System;
    using System.Web.Mvc;
    public class CustomMetadataAttribure : Attribute, IMetadataAware
    {
        public string Key { get; set; }
        public CustomMetadataAttribure(string key) => this.Key = key;
        public void OnMetadataCreated(ModelMetadata metadata)
        {
            metadata.DisplayName = TextManager.GetValue(this.Key);
        }
    }
