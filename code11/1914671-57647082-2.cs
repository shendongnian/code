     Type t = Type.GetType("PushButton_ViewModel");
     object obj = FormatterServices.GetUninitializedObject(t);
     IPlugin instance = obj as IPlugin;
     instance.NameUC = "the name";
     instance.Callbacks = new CallbacksModel();
