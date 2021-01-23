        public void Source_Get(string memberName)
        {
            object member = pFBlock.GetMember(memberName);
            MethodInfo mi = member.GetType().GetMethod("SendGet");
            if (mi != null)
            {
                ParameterInfo[] piArr = mi.GetParameters();
                if (piArr.Length == 0)
                {
                    mi.Invoke(member, new object[0]);
                }
            }
        }
