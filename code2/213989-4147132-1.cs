    using System.Linq.Expressions;
    using System.Reflection;
    using System.Reflection.Emit;
    ...
            var mtype = compiled.Method.GetType();
            var fiOwner = mtype.GetField("m_owner", BindingFlags.Instance | BindingFlags.NonPublic);
            var dynMethod = fiOwner.GetValue(compiled.Method) as DynamicMethod;
            var ilgen = dynMethod.GetILGenerator();
            var fiBytes = ilgen.GetType().GetField("m_ILStream", BindingFlags.Instance | BindingFlags.NonPublic);
            var fiLength = ilgen.GetType().GetField("m_length", BindingFlags.Instance | BindingFlags.NonPublic);
            byte[] il = fiBytes.GetValue(ilgen) as byte[];
            int cnt = (int)fiLength.GetValue(ilgen);
            // Dump <cnt> bytes from <il>
            //...
