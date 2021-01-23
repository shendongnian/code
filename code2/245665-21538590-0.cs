        /// <summary>
        /// This solutions works for all unicode string values.
        /// </summary>
        /// <remarks>2n time complexity. Dictionary insertion and retrieval will be minimal</remarks>
        public static bool Anagram(string valueA, string valueB)
        {
            if (string.IsNullOrWhiteSpace(valueA) || string.IsNullOrWhiteSpace(valueB))
            {
                return false;
            }
            if (valueA.Length != valueB.Length)
            {
                return false;
            }
            if (valueA.Equals(valueB))
            {
                return false;
            }
            var values = new Dictionary<char, int>();
            foreach (char key in valueA)
            {
                if (!values.ContainsKey(key))
                {
                    values[key] = 1;
                }
                else
                {
                    values[key] += 1;
                }
            }
            var uniqueCharacters = values.Keys.Count;
            for (var i = 0; i < valueB.Length; i++)
            {
                char item = valueB[i];
                if (!values.ContainsKey(item) || values[item] == 0)
                {
                    return false; // too many occurances of char found
                }
                values[item] -= 1;
                if (values[item] == 0)
                {
                    uniqueCharacters -= 1;
                    if (uniqueCharacters == 0)
                    {
                        return i == valueB.Length - 1;
                    }
                }
            }
            return false;
        }
            [Test]
            public void Anagram3Test()
            {
                Assert.That(Anagram3(null, null), Is.False);
                Assert.That(Anagram3(string.Empty, null), Is.False);
                Assert.That(Anagram3("a", null), Is.False);
                Assert.That(Anagram3("ab", "ab"), Is.False);
                Assert.That(Anagram3("carthorses", "orchestra"), Is.False);
                Assert.That(Anagram3("orchestra", "carthorses"), Is.False);
                Assert.That(Anagram3("abc", "bce"), Is.False);
                Assert.That(Anagram3("orchestra", "carthorse"), Is.True);
            }
