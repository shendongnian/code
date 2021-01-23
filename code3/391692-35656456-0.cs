        [TestMethod]
        public void ReadLineWithNewLineOnly()
        {
            // Setup
            var text = $"ƒun ‼Æ¢ with åò☺ encoding!\nƒun ‼Æ¢ with åò☺ encoding!\nƒun ‼Æ¢ with åò☺ encoding!\nHa!";
            var bytes = Encoding.UTF8.GetBytes(text);
            var stream = new MemoryStream(bytes);
            var reader = new AdvancedStreamReader(stream, NewLineType.Nl);
            reader.ReadLine();
            // Execute
            var result = reader.ReadLine();
            // Assert
            Assert.AreEqual("ƒun ‼Æ¢ with åò☺ encoding!", result);
            Assert.AreEqual(54, reader.CharacterPosition);
        }
        [TestMethod]
        public void SeekCharacterWithUtf8()
        {
            // Setup
            var text = $"ƒun ‼Æ¢ with åò☺ encoding!{NL}ƒun ‼Æ¢ with åò☺ encoding!{NL}ƒun ‼Æ¢ with åò☺ encoding!{NL}Ha!";
            var bytes = Encoding.UTF8.GetBytes(text);
            var stream = new MemoryStream(bytes);
            var reader = new AdvancedStreamReader(stream);
            // Pre-condition assert
            Assert.IsTrue(bytes.Length > text.Length); // More bytes than characters in sample text.
            // Execute
            reader.SeekCharacter(84);
            // Assert
            Assert.AreEqual(84, reader.CharacterPosition);
            Assert.AreEqual($"Ha!", reader.ReadToEnd());
        }
