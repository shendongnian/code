        /// <summary>
        /// Retrieves the dialling code.
        /// </summary>
        /// <param name="culture">The culture.</param>
        /// <returns></returns>
        public static string RetrieveDiallingCode(string culture)
        {
            string value = "+44";
            switch (culture)
            {
                case "sv-SE":
                    value = "+46";
                    break;
                case "de-DE":
                    value = "+49";
                    break;
                case "fr-FR":
                    value = "+33";
                    break;
                case "fi-FI":
                    value = "+358";
                    break;
                case "en-US":
                    value = "+1";
                    break;
                default:
                    value = "+44";
                    break;
            }
            return value;
        }
