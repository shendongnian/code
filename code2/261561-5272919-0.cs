    string xml =@"<Labs>
      <Lab id='a'>
        <Test name='aa'></Test>
        <Test name='ab'></Test>
        <Test name='ac'></Test>
      </Lab>
      <Lab id='b'>
        <Test name='ba'></Test>
        <Test name='bb'></Test>
      </Lab>
    </Labs>";
	XDocument document = XDocument.Parse(xml);
	IEnumerable<XElement> xElements = document.Descendants().Where(e => e.Name == "Test");
	var results =  xElements.Select(m => new
	                                     	{
	                                     		Test = m.Attributes("name").FirstOrDefault().Value, 
														Lab =m.Parent.Attributes("id").FirstOrDefault().Value
	                                     	});
			foreach (var result in results)
	{
				Console.Write(result.Lab);
				Console.Write('\t');
				Console.WriteLine(result.Test);
	}
