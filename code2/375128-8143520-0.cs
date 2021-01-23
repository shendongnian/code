                while ( true )
                {
                    DirectoryInfo parent = Directory.GetParent(current.FullName);
                    if ( parent.GetFiles().Length == 0 && parent.GetDirectories().Length == 0 )
                    {
                        current = parent;
                        current.Delete();
                    }
                    else
                    {
                        break;
                    }
                        
                }
