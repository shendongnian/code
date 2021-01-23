    public static void Main(string[] args)
    {
        if (args.Length > 0 && args[0] == "debug-dump")
        {   //debug-dump process by id = args[1], output = args[2]
            using (XmlTextWriter wtr = new XmlTextWriter(args[2], Encoding.ASCII))
            {
                wtr.Formatting = Formatting.Indented;
                PerformDebugDump(Int32.Parse(args[1]), wtr);
            }
            return;
        }
        //... continue normal program execution
    }
    static void PerformDebugDump(int process, XmlWriter x)
    {
        x.WriteStartElement("process");
        x.WriteAttributeString("id", process.ToString());
        x.WriteAttributeString("time", XmlConvert.ToString(DateTime.Now, XmlDateTimeSerializationMode.RoundtripKind));
        MDbgEngine e = new MDbgEngine();
        MDbgProcess me = e.Attach(process);
        me.Go().WaitOne();
        try
        {
            x.WriteStartElement("modules");
            foreach (MDbgModule mod in me.Modules)
                x.WriteElementString("module", mod.CorModule.Name);
            x.WriteEndElement();
            foreach (MDbgThread thread in me.Threads)
            {
                x.WriteStartElement("thread");
                x.WriteAttributeString("id", thread.Id.ToString());
                x.WriteAttributeString("number", thread.Number.ToString());
                int ixstack = -1;
                foreach (MDbgFrame frame in thread.Frames)
                {
                    x.WriteStartElement("frame");
                    x.WriteAttributeString("ix", (++ixstack).ToString());
                    x.WriteAttributeString("loc", frame.ToString(String.Empty));
                    string valueText = null;
                    x.WriteStartElement("args");
                    try
                    {
                        foreach (MDbgValue value in frame.Function.GetArguments(frame))
                        {
                            x.WriteStartElement(value.Name);
                            x.WriteAttributeString("type", value.TypeName);
                            try { x.WriteAttributeString("value", value.GetStringValue(1, false)); }
                            finally { x.WriteEndElement(); }
                        }
                    }
                    catch { }
                    x.WriteEndElement();
                    x.WriteStartElement("locals");
                    try
                    {
                        foreach (MDbgValue value in frame.Function.GetActiveLocalVars(frame))
                        {
                            x.WriteStartElement(value.Name);
                            x.WriteAttributeString("type", value.TypeName);
                            try { x.WriteAttributeString("value", value.GetStringValue(1, false)); }
                            finally { x.WriteEndElement(); }
                        }
                    }
                    catch { }
                    x.WriteEndElement();
                    x.WriteEndElement();
                }
                x.WriteEndElement();
            }
        }
        finally
        {
            me.Detach().WaitOne();
        }
        x.WriteEndElement();
    }
