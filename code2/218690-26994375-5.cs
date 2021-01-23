    public class ColorParserTests
    {
    	public class TryParseHexTests
    	{
    		[TestMethod]
    		[ExpectedException(typeof(ArgumentNullException))]
    		public void TestNullValue()
    		{
    			Color color = Color.Empty;
    			ColorParser.TryParseHex(null, out color);
    		}
    
    		[TestMethod]
    		[ExpectedException(typeof(ArgumentNullException))]
    		public void TestEmptyValue()
    		{
    			Color color = Color.Empty;
    			ColorParser.TryParseHex(string.Empty, out color);
    		}
    
    		[TestMethod]
    		public void TestInvalidValues()
    		{
    			string[] invalidValues = new string[] 
    			{ 
    				"#",
    				"FF",
    				"#FF",
    				"#FFAA",
    				"asdf"
    			};
    			foreach (var invalidValue in invalidValues)
    			{
    				Color color = Color.Empty;
    				bool result = ColorParser.TryParseHex(invalidValue, out color);
    				Assert.IsFalse(result, string.Format("Value '{0}' must not pass the test!", invalidValue));
    			}
    		}
    
    		[TestMethod]
    		public void TestValidValues()
    		{
    			// Spaces are intended and a part of the test!
    			Dictionary<string, Color> validValues = new Dictionary<string, Color>() 
    			{ 
    				{"      #000000", Color.FromArgb(0,0,0)},
    				{" #010203  ", Color.FromArgb(1,2,3)},
    				{"#00FFFF", Color.FromArgb(0,255,255)},
    				{"#FF00FFFF", Color.FromArgb(255,0,255,255)},
    			};
    			foreach (var validValue in validValues)
    			{
    				Color color = Color.Empty;
    				bool result = ColorParser.TryParseHex(validValue.Key, out color);
    				Assert.IsTrue(result, string.Format("Value '{0}' must pass the test!", validValue.Key));
    				Assert.AreEqual(validValue.Value, color, "Parsed color must be the same.");
    			}
    		}
    	}
    }
