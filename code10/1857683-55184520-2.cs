            internal static bool IsEqual(this AuthorizationRuleCollection authorizationRuleCollectionA, AuthorizationRuleCollection authorizationRuleCollectionB)
        {
            if (authorizationRuleCollectionA.Count != authorizationRuleCollectionB.Count)
            {
                return false;
            }
            int hash1 = CalculateHash(authorizationRuleCollectionA);
            int hash2 = CalculateHash(authorizationRuleCollectionB);
            return hash1 == hash2;
        }
        /// <summary>
        /// Source: https://stackoverflow.com/a/263416/10585750
        /// </summary>
        /// <param name="authorizationRuleCollection"></param>
        private static int CalculateHash(AuthorizationRuleCollection authorizationRuleCollection)
        {
            unchecked
            {
                int hash = 17;
                foreach (FileSystemAccessRule fileSystemAccessRule in authorizationRuleCollection)
                {
                    hash += CalculateHash(fileSystemAccessRule);
                }
                return hash;
            }
        }
        private static int CalculateHash(FileSystemAccessRule fileSystemAccessRule)
        {
            unchecked
            {
                int hash = 23 * fileSystemAccessRule.IdentityReference.Value.GetHashCode()
                    * fileSystemAccessRule.InheritanceFlags.ToString().GetHashCode()
                    * fileSystemAccessRule.IsInherited.ToString().GetHashCode()
                    * fileSystemAccessRule.PropagationFlags.ToString().GetHashCode()
                    * fileSystemAccessRule.FileSystemRights.ToString().GetHashCode()
                    * fileSystemAccessRule.AccessControlType.ToString().GetHashCode();
                return hash;
            }
        }
