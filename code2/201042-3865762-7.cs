	protected override void Render(HtmlTextWriter writer)
	{
		base.Render(writer);
		writer.WriteBeginTag("input");
		writer.WriteAttribute("type", "hidden");
		writer.WriteAttribute("name", this.UniqueID);
		writer.WriteAttribute("value", "post");
		writer.Write(" />");
	}
