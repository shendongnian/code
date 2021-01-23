    if (instance != null && instance.Id != Guid.Empty && !Session.Contains(instance))
        using (Audit.LockAudit())
        {
            Session.Update(instance);
        }
}
         </li>
         <li>References a neat little helper class called 'Lazy Initializer for NHibernate' found here: <a href="http://www.codeproject.com/KB/cs/NHibernateLazyInitializer.aspx">http://www.codeproject.com/KB/cs/NHibernateLazyInitializer.aspx</a></li>
         <li>This also contains Extension methods for Save, Delete and LoadFullObject</li>
         <li>
         Have broken standards a little in this assembly by also creating a WrapUOW method to help simplify some of my code
            <pre><code>protected static T WrapUOW<T>(Func<T> action)
