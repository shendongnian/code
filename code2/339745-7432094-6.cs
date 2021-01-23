			var stringBuilder = new StringBuilder();
			var stream = new Stream(stringBuilder);
			stream
				.Serialize(1)
				.IsolateMemento(s=>new StreamMemento(s),s=>s
					.Serialize(new Formatter("formatted {0}"))
					.Serialize(2))
				.Serialize(3);
			Assert.AreEqual("1;formatted 2;3;", stringBuilder.ToString());
