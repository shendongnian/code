    ```csharp
    public class MyRole: IdentityRole<int>
    {
        [Column("RoleId")]
        public override int Id { get; set; }
    
        [Column("RoleName")]
        public override string Name { get; set; }
    }
    ```
