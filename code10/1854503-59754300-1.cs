	public class SubScriber
		{
			[CompilerGenerated]
			private sealed class <>c__DisplayClass0_0
			{
				public int i;
				internal void ctor>b__0()
				{
					Console.WriteLine("Event Fired action1");
					this.i = 11;
				}
			}
			[CompilerGenerated]
			[Serializable]
			private sealed class <>c
			{
				public static readonly Program.SubScriber.<>c <>9 = new Program.SubScriber.<>c();
				public static Action <>9__0_1;
				internal void ctor>b__0_1()
				{
					Console.WriteLine("Event Fired action2");
				}
			}
			public SubScriber()
			{
				Program.SubScriber.<>c__DisplayClass0_0 <>c__DisplayClass0_ = new Program.SubScriber.<>c__DisplayClass0_0();
				<>c__DisplayClass0_.i = 5;
				Action action = new Action(<>c__DisplayClass0_.<.ctor>b__0);
				Action arg_41_0;
				if ((arg_41_0 = Program.SubScriber.<>c.<>9__0_1) == null)
				{
					arg_41_0 = (Program.SubScriber.<>c.<>9__0_1 = new Action(Program.SubScriber.<>c.<>9.<.ctor>b__0_1));
				}
				Action action2 = arg_41_0;
				string arg_59_0 = "Target 1 = ";
				object expr_4D = action.Target;
				Console.WriteLine(arg_59_0 + ((expr_4D != null) ? expr_4D.ToString() : null));
				string arg_7B_0 = "Target 2 = ";
				object expr_6F = action2.Target;
				Console.WriteLine(arg_7B_0 + ((expr_6F != null) ? expr_6F.ToString() : null));
				Program.PrismEvents.EventTest.Subscribe(action);
				Program.PrismEvents.EventTest.Subscribe(action2);
			}
			~SubScriber()
			{
				Console.WriteLine("SubScriber destructed");
			}
		}
