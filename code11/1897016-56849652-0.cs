string input = @"<root>
<Settings>
	<A> 1 </A>
	<B> 2 </B>
	<C> 3 </C>
	<D> 4 </D>
</Settings>
<Hello>World</Hello>
<Foo>Bar</Foo>
</root>";
		
XDocument xdoc = XDocument.Parse(input);
var result = xdoc.Descendants("Settings")
	.Elements()
	.ToDictionary(
		el => el.Name.LocalName,
		el => el.Value 
	);
result.Dump();
Result:
Dumping object(System.Collections.Generic.Dictionary`2[String,String])
  [
   [A,  1 ]
   ,
   [B,  2 ]
   ,
   [C,  3 ]
   ,
   [D,  4 ]
]
Acessing value like `settings["A"]`.
[LiveDemo](https://dotnetfiddle.net/7q51IM)
