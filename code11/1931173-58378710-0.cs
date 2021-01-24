    public static class LocalSettingsHelper
    {
        private static ApplicationDataContainer _localSettings = ApplicationData.Current.LocalSettings;
        /// <summary>
        /// Create Local Settings storage Container
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="container">Container</param>
        /// <param name="containerValue">ContainerValue</param>
        /// <param name="value">Value</param>
        internal static void SetContainer<T>(string container, string containerValue, T value)
        {
            var containerName = _localSettings.CreateContainer(container, ApplicationDataCreateDisposition.Always);
            _localSettings.Containers[container].Values[containerValue] = value != null ? JsonConvert.SerializeObject(value) : null;
        }
        /// <summary>
        /// Get Local Settings Container 
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="container">Container</param>
        /// <param name="containerValue">ContainerValue</param>
        /// <returns>Value as Type</returns>
        internal static T GetContainerValue<T>(string container, string containerValue)
        {
            var containerName = _localSettings.CreateContainer(container, ApplicationDataCreateDisposition.Always);
            string currentValue = _localSettings.Containers[container].Values[containerValue] as string;
            if (currentValue == null)
            {
                return default(T);
            }
            return JsonConvert.DeserializeObject<T>(currentValue);
        }
    }
