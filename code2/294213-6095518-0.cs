    [TestClass]
	public class UnitTest1
	{
		public class Creator
		{
			private static Dictionary<string,Func<XElement, Control>> _map = new Dictionary<string, Func<XElement,Control>>();
			public static Control Create(XElement element)
			{
				var create = GetCreator(element.Attribute("Type").Value);
				return create(element);
			}
			private static Expression<Func<XElement, string>> CreateXmlAttributeAccessor(string elementName)
			{
				return (xl => xl.Attributes(elementName).Select(el => el.Value).FirstOrDefault() ?? "_" + elementName);
			}
			private static Func<XElement, Control> GetCreator(string typeName)
			{
				Func<XElement, Control> existing;
				if (_map.TryGetValue(typeName, out existing))
					return existing;
				// mapping for whatever property names you wish
				var propMapping = new[]
             	{
             		new{ Name = "Name", Getter = CreateXmlAttributeAccessor("Name") },
					new{ Name = "Content", Getter = CreateXmlAttributeAccessor("Value") },
             	};
				
				var t = Assembly.GetAssembly(typeof (Control)).GetType("System.Windows.Controls." + typeName);
				var elementParameter = Expression.Parameter(typeof (XElement), "element");
				var p = from propItem in propMapping
						let member = t.GetMember(propItem.Name)
						where member.Length != 0
						select (MemberBinding)Expression.Bind(member[0], Expression.Invoke(propItem.Getter, elementParameter));
				var expression = Expression.Lambda<Func<XElement, Control>>(
					Expression.MemberInit(Expression.New(t),p), elementParameter);
				
				existing = expression.Compile();
				_map[typeName] = existing;
				return existing;
			}
		}
		[TestMethod]
		public void TestMethod1()
		{
			var xel = new XElement("control",
				new XAttribute("Type", "Button"),
				new XAttribute("Name", "Foo"),
				new XAttribute("Value", "Bar"),
				new XElement("NonExistent", "foobar")); // To check stability
			var button = (Button) Creator.Create(xel);
			Assert.AreEqual("Foo", button.Name);
			Assert.AreEqual("Bar", button.Content);
		}
	}
