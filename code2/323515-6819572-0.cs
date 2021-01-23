        /// <summary>
    /// Displays form in mdi form once
    /// </summary>
    /// <autor>Saber Amani</autor>
    /// <lastUpdate>2009-03-03</lastUpdate>
    public class MdiFormDisplayer
    {
        private Hashtable fForms = new Hashtable();
        private object fSender = null;
        public MdiFormDisplayer(object sender)
        {
            fSender = sender;
        }
        public Form GetForm(Type formType)
        {
            string formName = formType.Name;
            Form frm = (Form)fForms[formName];
            if (frm == null || frm.IsDisposed)
            {
                frm = CreateNewInstance(formType);
                fForms[formName] = frm;
            }
            return frm;
        }
        public Form GetForm(string formName)
        {
            if (fSender == null)
                throw new ArgumentNullException("Sender", "Sender can't be null");
            return GetForm(fSender, formName);
        }
        public Form GetForm(object sender, string formName)
        {
            Form frm = (Form)fForms[formName];
            if (frm == null || frm.IsDisposed)
            {
                frm = CreateNewInstance(sender, formName);
                fForms[formName] = frm;
            }
            return frm;
        }
        private Form CreateNewInstance(object sender, string formName)
        {
            Type frmType;
            frmType = FindFormType(sender, formName);
            Form frmInstance = (Form)CallTypeConstructor(frmType);
            return frmInstance;
        }
        private Form CreateNewInstance(Type frmType)
        {
            Form frmInstance = (Form)CallTypeConstructor(frmType);
            return frmInstance;
        }
        private Type FindFormType(object sender, string formName)
        {
            Type baseType = sender.GetType();
            Assembly senderAssembly = Assembly.GetAssembly(baseType);
            Type result = null;
            // Search with assembly standard method
            result = senderAssembly.GetType(baseType.Namespace + "." + formName);
            if (result != null)
                return result;
            // Search with in the types
            Type[] assemblyTypes = senderAssembly.GetTypes();
            formName = formName.ToLower();
            for (int i = 0; i < assemblyTypes.Length; i++)
            {
                if (assemblyTypes[i].Name.ToLower() == formName)
                    return assemblyTypes[i];
            }
            return null;
        }
        private object CallTypeConstructor(Type frmType)
        {
            Type[] contructTypes = new Type[] { };
            ConstructorInfo constructorObj = frmType.GetConstructor(contructTypes);
            object result = constructorObj.Invoke(null);
            return result;
        }
    }
