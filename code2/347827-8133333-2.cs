            /// <summary>
            /// Gets the String representation for this enums choosen 
            /// </summary>
            /// <param name="e">Instance of the enum chosen</param>
            /// <returns>Name of the chosen enum in String representation</returns>
            public static String GetName(this EAccountStatus e)
            {
                return Enum.GetName(typeof(EAccountStatus), e);
            }
        }
    }
