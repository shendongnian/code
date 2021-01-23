    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var s1 = "myfinename_slice_1.tif";
            var s2 = "myfilename_slice_2.tif";
            var s3 = "myfilename_slice_15.tif";
            var s4 = "myfilename_slice_210.tif";
            var s5 = "myfilena44me_slice_210.tif";
            var s6 = "7myfilena44me_slice_210.tif";
            var s7 = "tif999";
            Assert.AreEqual(1, EnumerateNumbers(s1).First());
            Assert.AreEqual(2, EnumerateNumbers(s2).First());
            Assert.AreEqual(15, EnumerateNumbers(s3).First());
            Assert.AreEqual(210, EnumerateNumbers(s4).First());
            Assert.AreEqual(210, EnumerateNumbers(s5).Skip(1).First());
            Assert.AreEqual(210, EnumerateNumbers(s6).Skip(2).First());
            Assert.AreEqual(44, EnumerateNumbers(s6).Skip(1).First());
            Assert.AreEqual(999, EnumerateNumbers(s7).First());
        }
        static IEnumerable<int> EnumerateNumbers(string input)
        {
            var digits = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            string result = string.Empty;
            foreach (var c in input.ToCharArray())
            {
                if (!digits.Contains(c))
                {
                    if (!string.IsNullOrEmpty(result))
                    {
                        yield return int.Parse(result);
                        result = string.Empty;
                    }
                }
                else
                {
                    result += c;      
                }
            }
            if (result.Length > 0) 
                yield return int.Parse(result);
        }
    }
