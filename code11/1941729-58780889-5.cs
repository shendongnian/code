		public void Main()
		{
            string name = "mark";
            string v = $"Hello, {name}!";
            bool fireagain = false;
            Dts.Events.FireInformation(0, "Really worked", v, string.Empty, 0, ref fireagain);
            Dts.TaskResult = (int)ScriptResults.Success;
		}
