    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class RequiredResourceAccess
    {
        /// <summary>
        /// The unique identifier for the resource that the application requires access to.
        /// This should be equal to the appId declared on the target resource application
        /// </summary>
        [JsonProperty("resourceAppId")]
        public string ResourceAppId { get; set; }
        /// <summary>
        /// The list of OAuth2.0 permission scopes and app roles that the application requires from the specified resource.
        /// </summary>
        [JsonProperty("resourceAccess")]
        public List<ResourceAccess> ResourceAccess { get; set; }
    }
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class ResourceAccess
    {
        /// <summary>
        /// The unique identifier for one of the oAuth2Permission or appRole instances that the resource application exposes.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }
        /// <summary>
        /// Specifies whether the id property references an oAuth2Permission or an appRole. Possible values are "scope" or "role".
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }    
