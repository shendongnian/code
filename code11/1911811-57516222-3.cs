public class FormidableFormsResponse
{
	[JsonProperty("id")]
	public long Id { get; set; }
	[JsonProperty("item_key")]
	public string ItemKey { get; set; }
	[JsonProperty("name")]
	public string Name { get; set; }
	[JsonProperty("ip")]
	public string Ip { get; set; }
	[JsonProperty("meta")]
	public Meta Meta { get; set; }
	[JsonProperty("form_id")]
	public long FormId { get; set; }
	[JsonProperty("post_id")]
	public long PostId { get; set; }
	[JsonProperty("user_id")]
	public long UserId { get; set; }
	[JsonProperty("parent_item_id")]
	public long ParentItemId { get; set; }
	[JsonProperty("is_draft")]
	public long IsDraft { get; set; }
	[JsonProperty("updated_by")]
	public long UpdatedBy { get; set; }
	[JsonProperty("created_at")]
	public DateTimeOffset CreatedAt { get; set; }
	[JsonProperty("updated_at")]
	public DateTimeOffset UpdatedAt { get; set; }
}
public class Meta
{
	[JsonProperty("first_name")]
	public string FirstName { get; set; }
	[JsonProperty("middle_initial")]
	public string MiddleInitial { get; set; }
	[JsonProperty("last_name")]
	public string LastName { get; set; }
	[JsonProperty("date")]
	public string Date { get; set; }
	[JsonProperty("date-value")]
	public DateTimeOffset DateValue { get; set; }
}
Try it: [fiddle](https://dotnetfiddle.net/T25L3N)
