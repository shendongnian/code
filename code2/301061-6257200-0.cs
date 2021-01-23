        [TestMethod()]
        public void TestJoin()
        {
            var list1 = new List<Object1>();
            var list2 = new List<Object2>();
            list1.Add(new Object1 { Prop1 = 1, Prop2 = "2" });
            list1.Add(new Object1 { Prop1 = 4, Prop2 = "2av" });
            list1.Add(new Object1 { Prop1 = 5, Prop2 = "2gks" });
            list2.Add(new Object2 { Prop1 = 3, Prop2 = "wq" });
            list2.Add(new Object2 { Prop1 = 9, Prop2 = "sdf" });
            var list = (from l1 in list1
                        from l2 in list2
                        select l1).ToList();
            Assert.AreEqual(6, list.Count);
        }
