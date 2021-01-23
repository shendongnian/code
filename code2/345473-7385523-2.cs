    public static T Load(string fileName)
    {
        T t = new T();
			if (File.Exists(fileName))
				t = (new JavaScriptSerializer()).Deserialize<T>(File.ReadAllText(fileName));
			else
				Save(t);
        return t;
    }
