			NSDictionary dict = NSDictionary.FromObjectsAndKeys (new object[] { "user1", "user2" }, new object[] { "123", "abc" });
			NSString key = new NSString ("dict");
			NSUserDefaults.StandardUserDefaults.SetValueForKey (dict, key);
			NSDictionary d2 = NSUserDefaults.StandardUserDefaults.DictionaryForKey (key);
			for (int i = 0; i < d2.Count; i++) {
				Console.WriteLine ("{0} : {1}", d2.Keys [i], d2.Values [i]);
			}
