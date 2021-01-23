    //Justification
    aRow.Descendants<TableCell>().ElementAt(indx).Descendants<Paragraph>()
       	.ElementAt(0).ParagraphProperties = new ParagraphProperties()
       	{
       		Justification = new Justification()
       		{
       			Val = new EnumValue<JustificationValues>(JustificationValues.Right)
       		}
       	};
       
    //RightToLeftText
    foreach (var r in aRow.Descendants<TableCell>().ElementAt(indx).Descendants<Run>())
    {
       	r.RunProperties = new RunProperties()
       	{
       		RightToLeftText = new RightToLeftText()
       		{
       			Val = new OnOffValue(true)
       		}
       	};
    }
