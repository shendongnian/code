public class FirefoxOptions : DriverOptions
...
        /// <summary>
        /// Provides a means to add additional capabilities not yet added as type safe options
        /// for the Firefox driver.
        /// </summary>
        /// <param name="optionName">The name of the capability to add.</param>
        /// <param name="optionValue">The value of the capability to add.</param>
        /// <exception cref="ArgumentException">
        /// thrown when attempting to add a capability for which there is already a type safe option, or
        /// when <paramref name="optionName"/> is <see langword="null"/> or the empty string.
        /// </exception>
        /// <remarks>Calling <see cref="AddAdditionalFirefoxOption(string, object)"/>
        /// where <paramref name="optionName"/> has already been added will overwrite the
        /// existing value with the new value in <paramref name="optionValue"/>.
        /// Calling this method adds capabilities to the Firefox-specific options object passed to
        /// geckodriver.exe (property name 'moz:firefoxOptions').</remarks>
        public void AddAdditionalFirefoxOption(string optionName, object optionValue)
        {
            this.ValidateCapabilityName(optionName);
            this.additionalFirefoxOptions[optionName] = optionValue;
        }
...
  [1]: https://github.com/SeleniumHQ/selenium/blob/master/dotnet/src/webdriver/Firefox/FirefoxOptions.cs
