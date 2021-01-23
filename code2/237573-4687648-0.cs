		[Test]
		public void Foo()
		{
			var a = new A
			{
				B = new B
				{
					C = new C
					{
						Name = "hello"
					}
				}
			};
			DoReflection(a);
		}
		private void DoReflection(dynamic value)
		{
			string message = value.B.C.Name;
			Debug.WriteLine(message);
		}
