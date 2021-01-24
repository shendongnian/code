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
                foreach (AuthorizationRule authorizationRule in authorizationRuleCollection)
                {
                    hash += CalculateHash(authorizationRule);
                }
                return hash;
            }
        }
        internal static int CalculateHash(AuthorizationRule authorizationRule)
        {
            unchecked
            {
                int hash = 23 * authorizationRule.IdentityReference.Value.GetHashCode()
                    * authorizationRule.InheritanceFlags.GetHashCode()
                    * authorizationRule.IsInherited.GetHashCode()
                    * authorizationRule.PropagationFlags.GetHashCode();
                return hash;
            }
        }
