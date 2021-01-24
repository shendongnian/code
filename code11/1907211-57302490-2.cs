        private const string UseSpecCompliantProtocolOption = "w3c";
        private bool useSpecCompliantProtocol = true;
            /// <summary>
            /// Gets or sets a value indicating whether the <see cref="ChromiumDriver"/> instance
            /// should use the legacy OSS protocol dialect or a dialect compliant with the W3C
            /// WebDriver Specification.
            /// </summary>
            public bool UseSpecCompliantProtocol
            {
                get { return this.useSpecCompliantProtocol; }
                set { this.useSpecCompliantProtocol = value; }
            }
