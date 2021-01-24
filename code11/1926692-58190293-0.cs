    public partial class NewBusinessMaster
    {
        public NewBusinessMaster()
        {
            NewBusinessDetail = new HashSet<NewBusinessDetail>();
        }
        public int NbTransactionId { get; set; }
        public string NbLob { get; set; }
        public string NbReferenceNumber { get; set; }
        public string NbAgentNumber { get; set; }
        public string NbEntryOper { get; set; }
        public string NbEffectiveDate { get; set; }
        public string NbInsName { get; set; }
        public string NbInsNameAddr { get; set; }
        public string NbInsAddr { get; set; }
        public string NbInsCity { get; set; }
        public string NbInsState { get; set; }
        public string NbInsZip { get; set; }
        public string NbInsPhone { get; set; }
        public string NbUploadInd { get; set; }
        public DateTime NbCreateDate { get; set; }
        public string NbLockedBy { get; set; }
        public string NbQuoteId { get; set; }
        public virtual ICollection<NewBusinessDetail> NewBusinessDetail { get; set; }
    }
    public partial class NewBusinessDetail
    {
        public int NewBusinessDetailId { get; set; }
        public int NbTransactionId { get; set; }
        public string NbAgentNumber { get; set; }
        public string NbScreenName { get; set; }
        public string NbFieldName { get; set; }
        public string NbFieldValue { get; set; }
        public DateTime? NbLastUpdated { get; set; }
        public virtual NewBusinessMaster NbTransaction { get; set; }
    }
    //Context
    public partial class DharmaContext : DbContext
    {
        public DharmaContext()
        {
        }
        public DharmaContext(DbContextOptions<DharmaContext> options)
            : base(options)
        {
        }
        public virtual DbSet<NewBusinessDetail> NewBusinessDetail { get; set; }
        public virtual DbSet<NewBusinessMaster> NewBusinessMaster { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");
            modelBuilder.Entity<NewBusinessDetail>(entity =>
            {
                entity.Property(e => e.NewBusinessDetailId).HasColumnName("NewBusinessDetail_ID");
                entity.Property(e => e.NbAgentNumber)
                    .IsRequired()
                    .HasColumnName("NB_AGENT_NUMBER")
                    .HasMaxLength(9)
                    .IsUnicode(false);
                entity.Property(e => e.NbFieldName)
                    .HasColumnName("NB_FIELD_NAME")
                    .HasMaxLength(8)
                    .IsUnicode(false);
                entity.Property(e => e.NbFieldValue)
                    .HasColumnName("NB_FIELD_VALUE")
                    .HasMaxLength(1000)
                    .IsUnicode(false);
                entity.Property(e => e.NbLastUpdated)
                    .HasColumnName("NB_LAST_UPDATED")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
                entity.Property(e => e.NbScreenName)
                    .HasColumnName("NB_SCREEN_NAME")
                    .HasMaxLength(4)
                    .IsUnicode(false);
                entity.Property(e => e.NbTransactionId).HasColumnName("NB_TRANSACTION_ID");
                entity.HasOne(d => d.NbTransaction)
                    .WithMany(p => p.NewBusinessDetail)
                    .HasForeignKey(d => d.NbTransactionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("MasterDetail_FK");
            });
            modelBuilder.Entity<NewBusinessMaster>(entity =>
            {
                entity.HasKey(e => e.NbTransactionId);
                entity.Property(e => e.NbTransactionId).HasColumnName("NB_TRANSACTION_ID");
                entity.Property(e => e.NbAgentNumber)
                    .IsRequired()
                    .HasColumnName("NB_AGENT_NUMBER")
                    .HasMaxLength(9)
                    .IsUnicode(false);
                entity.Property(e => e.NbCreateDate)
                    .HasColumnName("NB_CREATE_DATE")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
                entity.Property(e => e.NbEffectiveDate)
                    .HasColumnName("NB_EFFECTIVE_DATE")
                    .HasMaxLength(6)
                    .IsUnicode(false);
                entity.Property(e => e.NbEntryOper)
                    .IsRequired()
                    .HasColumnName("NB_ENTRY_OPER")
                    .HasMaxLength(3)
                    .IsUnicode(false);
                entity.Property(e => e.NbInsAddr)
                    .HasColumnName("NB_INS_ADDR")
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.NbInsCity)
                    .HasColumnName("NB_INS_CITY")
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.NbInsName)
                    .HasColumnName("NB_INS_NAME")
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.NbInsNameAddr)
                    .HasColumnName("NB_INS_NAME_ADDR")
                    .HasMaxLength(30)
                    .IsUnicode(false);
                entity.Property(e => e.NbInsPhone)
                    .HasColumnName("NB_INS_PHONE")
                    .HasMaxLength(12)
                    .IsUnicode(false);
                entity.Property(e => e.NbInsState)
                    .HasColumnName("NB_INS_STATE")
                    .HasMaxLength(2)
                    .IsUnicode(false);
                entity.Property(e => e.NbInsZip)
                    .HasColumnName("NB_INS_ZIP")
                    .HasMaxLength(11)
                    .IsUnicode(false);
                entity.Property(e => e.NbLob)
                    .HasColumnName("NB_LOB")
                    .HasMaxLength(2)
                    .IsUnicode(false);
                entity.Property(e => e.NbLockedBy)
                    .HasColumnName("NB_LOCKED_BY")
                    .HasMaxLength(3)
                    .IsUnicode(false);
                entity.Property(e => e.NbQuoteId)
                    .HasColumnName("NB_QUOTE_ID")
                    .HasMaxLength(15)
                    .IsUnicode(false);
                entity.Property(e => e.NbReferenceNumber)
                    .IsRequired()
                    .HasColumnName("NB_REFERENCE_NUMBER")
                    .HasMaxLength(9)
                    .IsUnicode(false);
                entity.Property(e => e.NbUploadInd)
                    .HasColumnName("NB_UPLOAD_IND")
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });
        }
    
    //Code to add parent and child
    NewBusinessMaster nbMaster = new NewBusinessMaster();
    //set each property of master
    //...
    nbDetailItem = new NewBusinessDetail();
    nbMaster.NewBusinessDetail.Add(nbDetailItem);
    _context.NewBusinessMaster.Add(nbMaster);
     try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw;
            }
