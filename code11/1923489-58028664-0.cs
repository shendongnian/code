[ConfigurationProperty(ConfigKeys.UrlColumnName, IsRequired = true, DefaultValue = "Url")]
public string UrlColumnName { get; set; }
To:
[ConfigurationProperty(ConfigKeys.UrlColumnName, IsRequired = true, DefaultValue = "Url")]
public string UrlColumnName
{
    get => (string) this[ConfigKeys.UrlColumnName]; 
    set => this[ConfigKeys.UrlColumnName] = (string) value;
}
