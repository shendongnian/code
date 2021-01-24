C#
    /// <summary>
    /// Adds auditing properties to an entity.
    /// </summary>
    public interface IAuditedEntity
    {
        /// <summary>
        /// Date and time of the entity's creation. Usually in UTC.
        /// </summary>
        /// <remarks>Best set via a <see cref="ITimeProvider"/>.</remarks>
        DateTime DateCreated { get; set; }
        /// <summary>
        /// Identification who created this instance.
        /// </summary>
        /// <remarks>Best set via a <see cref="ICurrentUserIdProvider"/>.</remarks>
        string CreatedBy { get; set; }
        /// <summary>
        /// Date and time of last modification. Usually in UTC.
        /// </summary>
        /// <remarks>Best set via a <see cref="ITimeProvider"/>.</remarks>
        DateTime? DateModified { get; set; }
        /// <summary>
        /// Last one modifiying this instance.
        /// </summary>
        /// <remarks>Best set via a <see cref="ICurrentUserIdProvider"/>.</remarks>
       string ModifiedBy { get; set; }
}
The user provider interface is defined like this:
C#
    /// <summary>
    /// Interface for providing the current user's id.
    /// </summary>
    public interface ICurrentUserIdProvider
    {
        /// <summary>
        /// Get the id of the curent user.
        /// </summary>
        /// <returns></returns>
        string GetCurrentUserId();
    }
For testing purposes you now can use an [ambient context/service][2] delivering the current user or any user you need to test your logic.
  [1]: http://www.fiyazhasan.me/implementing-common-audit-fields-with-ef-cores-shadow-property/
  [2]: https://blog.ploeh.dk/2010/04/27/FunwithliteralextensionsandAmbientContext/
