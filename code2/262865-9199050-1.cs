    #if !NO_ASSEMBLY_SCANNING
                if (this.Settings.LoadExtensions)
                {
                    this.Load(new[] { this.Settings.ExtensionSearchPattern });
                }
    #endif
