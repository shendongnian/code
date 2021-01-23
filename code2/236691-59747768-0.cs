    /// <summary>
        /// This method call your method through Reflection 
        /// so i wil call the method like CallGenericMethodThroughReflection<Session>(assemblyQualifiedName,Linq,false,new[] { file }) 
        /// </summary>
        /// <typeparam name="T">Call method from which file</typeparam>
        /// <param name="assemblyQualifiedName">Your can get assemblyQualifiedName like typeof(Payroll.Domain.Attendance.AttendanceApplicationMaster).AssemblyQualifiedName</param>
        /// <param name="methodName"></param>
        /// <param name="isStaticMethod"></param>
        /// <param name="paramaterList"></param>
        /// <param name="parameterType">pass parameter type list in case of the given method have overload  </param>
        /// <returns>return object of calling method</returns>
        public static object CallGenericMethodThroughReflection<T>(string assemblyQualifiedName, string methodName,bool isStaticMethod ,object[] paramaterList,Type[] parameterType = null)
        {
            try
            {
                object instance = null;
                var bindingAttr = BindingFlags.Static | BindingFlags.Public;
                if (!isStaticMethod)
                {
                    instance = Activator.CreateInstance<T>();
                    bindingAttr = BindingFlags.Instance | BindingFlags.Public;
                }
                MethodInfo MI = null;
                var type = Type.GetType(assemblyQualifiedName);
                if(parameterType == null)
                    MI = typeof(T).GetMethod(methodName, bindingAttr);
                else
                    MI = typeof(T).GetMethod(methodName, bindingAttr,null, parameterType, null);//this will work in most case some case not work
                if (type == null || MI == null) // if the condition is true it means given method or AssemblyQualifiedName entity not found
                    return null;
                var genericMethod = MI.MakeGenericMethod(new[] { type });
                return genericMethod.Invoke(instance, paramaterList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
