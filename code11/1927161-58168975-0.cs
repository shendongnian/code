 public class EsMappingContract
{
	[PropertyName("doi")]
	public string Doi { get; set; }
	[PropertyName("displayName")]
	public string DisplayName { get; set; }
	[PropertyName("itemType")]
	public string ItemType { get; set; }
	[PropertyName("fileReference")]
	public string FileReference { get; set; }
}
Here's the Indexing Class
public class EsIndexingContract
{
	[PropertyName("doi")]
	public string Doi { get; set; }
	[PropertyName("displayName")]
	public string DisplayName { get; set; }
	[PropertyName("itemType")]
	public string ItemType { get; set; }
	[PropertyName("fileReference")]
	public string FileReference { get; set; }
	[PropertyName("citationTitle", Ignore = true)]
	public string CitationTitle { get; set; }
	[PropertyName("translatedPublicationTitle", Ignore = true)]
	public string TranslatedPublicationTitle { get; set; }
	[PropertyName("alternatePublicationTitle", Ignore = true)]
	public string AlternatePublicationTitle { get; set; }
	[PropertyName("publicationSubTitle", Ignore = true)]
	public string PublicationSubTitle { get; set; }
}
I didn't knew that ```[Ignore]``` will ignore the properties while indexing also and thus I had to go for this approach. I would have liked some other decorator that would have indicated ES to ignore while creating Mapping but should not be ignored on indexing, if the properties had value.
Thanks again for the help!! Hope this helps somebody in future.
