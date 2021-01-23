            ChildSource s = new ChildSource()
			{
				Value2 = 1,
				Value1 = 3
			};
			var c = s.MapTo<ChildDestination>();
			var c2 = s.MapTo<ParentDestination>();
			Assert.AreEqual( c.Value3, s.Value1 );
			Assert.AreEqual( c.Value4, s.Value2 );
			Assert.AreEqual( c2.Value3, s.Value1 );
			Assert.AreEqual( c.Value4, s.Value2 );
