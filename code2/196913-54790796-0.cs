        /// <summary>
        /// Use this extension method to get a strongly typed app setting from the configuration file.
        /// Returns app setting in configuration file if key found and tries to convert the value to a specified type. In case this fails, the fallback value
        /// or if NOT specified - default value - of the app setting is returned
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="appsettingKey"></param>
        /// <param name="fallback"></param>
        /// <returns></returns>
        public static T GetAppsetting<T>(string appsettingKey, T fallback = default(T))
        {
            string val = ConfigurationManager.AppSettings[appsettingKey] ?? "";
            if (!string.IsNullOrEmpty(val))
            {
                try
                {
                    Type typeDefault = typeof(T);
                    var converter = TypeDescriptor.GetConverter(typeof(T));
                    return converter.CanConvertFrom(typeof(string)) ? (T)converter.ConvertFrom(val) : fallback;
                }
                catch (Exception err)
                {
                    Console.WriteLine(err); //Swallow exception
                    return fallback;
                }
            }
            return fallback;
        }
    }
}
