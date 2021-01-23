            Type myObjectContextType = Type.GetType(context);            
            ConstructorInfo cs = myObjectContextType .GetConstructor(new Type[] { });
            dynamic myObjContext = cs.Invoke(new object[] { });
            Type t = Type.GetType(entity);
            ConstructorInfo xi = t.GetConstructor(new Type[] { });
            dynamic UserEntity = xi.Invoke(new object[] { });
            !problem here!
            ObjectSet<?????> os = myObjContext.UserEntity.Where(...) 
            return ...           
        }
