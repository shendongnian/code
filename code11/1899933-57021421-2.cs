				IAssemblyEnum pAssemblyEnum = null;
                IAssemblyName pAssemblyName = null;
                HRESULT hr = HRESULT.E_FAIL;
                string sAssemblyName = "mscorlib";
                hr = CreateAssemblyNameObject(out pAssemblyName, sAssemblyName, 0, IntPtr.Zero);
                if (hr == HRESULT.S_OK)
                {
                    hr = CreateAssemblyEnum(out pAssemblyEnum, IntPtr.Zero, pAssemblyName, ASM_CACHE_FLAGS.ASM_CACHE_GAC,  IntPtr.Zero);
                    if (hr == HRESULT.S_OK)
                    {
                        while (pAssemblyEnum.GetNextAssembly(IntPtr.Zero, out pAssemblyName, 0) == 0 && pAssemblyName != null)
                        {
                            int nSize = 260;
                            StringBuilder sbDisplayName = new StringBuilder(nSize);
                            hr = pAssemblyName.GetDisplayName(sbDisplayName, ref nSize, ASM_DISPLAY_FLAGS.ASM_DISPLAYF_FULL);
                            Console.WriteLine("Display Name: {0}", sbDisplayName.ToString());
                         }
                        Marshal.ReleaseComObject(pAssemblyEnum);
                    }
                }
