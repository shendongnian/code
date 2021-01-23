        public static bool IsImplementationOf(this Type checkMe, Type forMe)
        {
            foreach (Type iface in checkMe.GetInterfaces())
            {
                if (iface == forMe)
                    return true;
            }
            return false;
        }
