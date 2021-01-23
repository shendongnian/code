    void Main()
    {
        var sddl = "O:SYG:SYD:(A;CI;0xf03bf;;;SY)(A;;CCLO;;;LS)(A;;CCLO;;;NS)(A;;0xf03bf;;;BA)(A;;CC;;;IU)S:NO_ACCESS_CONTROL";
        
        SddlDecoder.DecodeString<FileSystemRights>(sddl).Dump("FileSystem");
        SddlDecoder.DecodeString<RegistryRights>(sddl).Dump("Registry");
        SddlDecoder.DecodeString<SemaphoreRights>(sddl).Dump("Semaphore");
    }
    
    // Define other methods and classes here
    public static class SddlDecoder
    {
        private static readonly ConcurrentDictionary<Type, Dictionary<uint, string>> _rights
            = new ConcurrentDictionary<Type, Dictionary<uint, string>>();
    
        public static string DecodeString<TRightsEnum>(string sddl) where TRightsEnum : struct
        {
            var rightsEnumType = typeof(TRightsEnum);
            if (!rightsEnumType.IsEnum ||
                Marshal.SizeOf(Enum.GetUnderlyingType(rightsEnumType)) != 4 ||
                !rightsEnumType.GetCustomAttributes(typeof(FlagsAttribute), true).Any())
            {
                throw new ArgumentException("TRightsEnum must be a 32-bit integer System.Enum with Flags attribute", "TRightsEnum");
            }
            else if (string.IsNullOrWhiteSpace(sddl))
                throw new ArgumentNullException("sddl");
    
            var descriptor = new RawSecurityDescriptor(sddl);
    
            var rights = _rights.GetOrAdd(rightsEnumType, 
                                          t => Enum.GetValues(rightsEnumType)
                                                   .Cast<uint>()
                                                   .Where(n => n != 0 && (n & (n - 1)) == 0)
                                                   .Distinct()
                                                   .OrderBy(n => n)
                                                   .Select(v => new { v, n = Enum.GetName(rightsEnumType, v) })
                                                   .ToDictionary(x => x.v, x => x.n));
    
            var builder = new StringBuilder();
    
            builder.Append("Owner: ").AppendLine(SidToAccountName(descriptor.Owner));
            builder.Append("Group: ").AppendLine(SidToAccountName(descriptor.Group));
    
            if (descriptor.SystemAcl != null)
            {
                builder.AppendLine("System ACL:");
                DecodeAclEntries(builder, descriptor.SystemAcl, rights);
            }
    
            if (descriptor.DiscretionaryAcl != null)
            {
                builder.AppendLine("Discretionary ACL:");
                DecodeAclEntries(builder, descriptor.DiscretionaryAcl, rights);
            }
    
            return builder.ToString();
        }
    
        private static string SidToAccountName(SecurityIdentifier sid)
        {
            return (sid.IsValidTargetType(typeof(NTAccount)))
                 ? ((NTAccount)sid.Translate(typeof(NTAccount))).Value
                 : sid.Value;
        }
    
        private static void DecodeAclEntries(StringBuilder builder, RawAcl acl, Dictionary<uint, string> rights)
        {
            var counter = 0;
            foreach (var ace in acl)
            {
                builder.Append("  #")
                       .Append(++counter)
                       .Append(": ");
    
                var knownAce = ace as KnownAce;
                if (knownAce != null)
                {
                    builder.Append(knownAce.AceType > AceType.MaxDefinedAceType
                                    ? "Custom Access"
                                    : knownAce.AceType.ToString())
                           .Append(" for ")
                           .Append(SidToAccountName(knownAce.SecurityIdentifier));
    
                    if (knownAce.AceFlags != AceFlags.None)
                    {
                        builder.Append(" (")
                               .Append(knownAce.AceFlags)
                               .Append(')');
                    }
    
                    builder.AppendLine();
    
                    var mask = unchecked((uint)knownAce.AccessMask);
    
                    foreach (var r in rights.Keys)
                    {
                        if ((mask & r) == r)
                        {
                            builder.Append("    - ")
                                   .AppendLine(rights[r]);
                        }
                    }
                }
                else builder.AppendLine("Unknown ACE");
            }
        }
    }
