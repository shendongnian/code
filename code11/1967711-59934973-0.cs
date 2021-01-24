public calss ProjectProgress {
    public int ProjectProgressId { get; set; }
    public int ProjectId { get; set; }
    public int ProgressId { get; set; }
    [MaxLength(250)]
    public string Notes { get; set; }
    public bool Complete { get; set; }
    public int? AddBy { get; set; }
    public System.DateTime AddDt { get; set; }
    public virtual Project Project { get; set; }
    public virtual Progress Progress { get; set; }
    [ForeignKey("AddBy")]
    public virtual UserProfile UserProfile { get; set; }
}
  [1]: https://docs.microsoft.com/en-us/ef/core/saving/cascade-delete
