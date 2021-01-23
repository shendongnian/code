      [Extension()]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void WriteInfo(string info)
        {
            try
            {
                MethodBase callingMethod = new StackFrame(1, true).GetMethod();
                string typeCalling = callingMethod.DeclaringType.FullName;
                string baseStr = "TYPE: {0}{3} METHOD: {1}{3} DETAIL: {2}";
                baseStr = string.Format(baseStr, new object[] {
	                                                        callingMethod,
	                                                        typeCalling,
	                                                        info,
	                                                        Environment.NewLine
		});
                EventLog.WriteEntry("entryName", baseStr, EventLogEntryType.Information);
            }
            catch
            {
                Debugger.Break();
            }
        }
