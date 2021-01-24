        [Test]
        public void ReadMessageProperly()
        {
            var message = CreateMessage();
            var body = message.Body;
            var text = Encoding.UTF8.GetString(body);
            var thingy = JsonConvert.DeserializeObject<Thingy>(text);
            Assert.IsInstanceOf<Thingy>(thingy);
            Assert.AreEqual("foobar", thingy.Doodad);
        }
