	class A {
		public virtual int X {
			get { return 1; }
		}
	}
	class B : A {
		public sealed override int X {
			get { return 2; }
		}
	}
	class C : B {
		public override int X {
			get { return -1; }
		}
	}
