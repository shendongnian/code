	public class EditFamilyMemberModel
	{
		#region Constructor
		public EditFamilyMemberModel(ITracktionDataLayer dataLayer, MessagePasser messager, AuthUserHelper authUser, int originalPersonID, int familyMemberID)
		{
			_dataLayer = dataLayer;
			_originalPerson = new PersonAddEditModel(messager, dataLayer, authUser, originalPersonID);
			_model = new PersonAddEditModel(messager, dataLayer, authUser, familyMemberID);
			_grades = _dataLayer.GetGradesForOrganization(authUser.OrganizationID, _model.Person.Grade, true).ToArray();
		}
		#endregion
		#region Private
		ITracktionDataLayer _dataLayer;
		PersonAddEditModel _originalPerson;
		PersonAddEditModel _model;
		IList<Grade> _grades;
		#endregion
		#region Properties
		#region Read Only
		public Person Person
		{
			get { return _model.Person; }
		}
		public AuthUserHelper AuthUser
		{
			get { return _model.AuthUser; }
		}
		public IList<School> Schools
		{
			get { return _model.Schools; }
		}
		public IList<ContactType> ContactTypes
		{
			get { return _model.ContactTypes; }
		}
		public IList<string> Genders
		{
			get { return _model.Genders; }
		}
		public IList<Grade> Grades
		{
			get { return /*_model.Grades;*/ _grades; }
		}
		public IList<USState> USStates
		{
			get { return _model.USStates; }
		}
		public IList<PersonType> PersonTypes
		{
			get { return _model.PersonTypes; }
		}
		public IList<FamilyRole> FamilyRoles
		{
			get { return _model.FamilyRoles; }
		}
		#endregion
		[Required]
		[StringLength(100)]
		public string Address
		{
			get { return _model.Person.Address; }
			set { _model.Person.Address = value; }
		}
		[StringLength(100)]
		public string Address2
		{
			get { return _model.Person.Address2; }
			set { _model.Person.Address2 = value; }
		}
		[Required]
		[StringLength(50)]
		public string City
		{
			get { return _model.Person.City; }
			set { _model.Person.City = value; }
		}
		[Required]
		[StringLength(50)]
		public string State
		{
			get { return _model.Person.State; }
			set { _model.Person.State = value; }
		}
		[Required]
		[StringLength(50)]
		public string Zip
		{
			get { return _model.Person.Zip; }
			set { _model.Person.Zip = value; }
		}
		[DataType(DataType.Date)]
		//[Required]
		public DateTime? DOB
		{
			get { return _model.Person.DOB; }
			set { _model.Person.DOB = value; }
		}
		[Required]
		public string Gender
		{
			get { return _model.Person.Gender; }
			set { _model.Person.Gender = value; }
		}
		[Required]
		public string FirstName
		{
			get { return _model.Person.FirstName; }
			set { _model.Person.FirstName = value; }
		}
		[Required]
		public string LastName
		{
			get { return _model.Person.LastName; }
			set { _model.Person.LastName = value; }
		}
		public int? SchoolID
		{
			get { return _model.Person.SchoolID; }
			set { _model.Person.SchoolID = value; }
		}
		public int? GradeID
		{
			get { return _model.Person.Grade; }
			set { _model.Person.Grade = value; }
		}
		public string SpecialNeedsDescription
		{
			get { return _model.Person.SpecialNeedsDescription; }
			set { _model.Person.SpecialNeedsDescription = value; }
		}
		public string SpecialNeedsSummary
		{
			get { return _model.Person.SpecialNeedsSummary; }
			set { _model.Person.SpecialNeedsSummary = value; }
		}
		public byte[] PictureData
		{
			get;
			set;
		}
		public string PictureAction
		{
			get;
			set;
		}
		#region Membership
		[Display(Name = "User Name")]
		[DisplayName("User Name")]
		[UniqueUserName(ErrorMessage = "The user name specified is already in use, please choose another user name.")]
		public string Username { get; set; }
		[Display(Name = "Password")]
		[DisplayName("Enter a password")]
		[StringLength(50, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters long.")]
		public string Password { get; set; }
		[DisplayName("Confirm Password")]
		[StringLength(50, MinimumLength = 6)]
		public string PasswordConfirm { get; set; }
		#endregion
		#region Abstracted Contact Methods
		/// <summary>
		/// When adding someone, this represents the phone number contact record.
		/// </summary>
		[Display(Name = "Home Phone Number")]
		[DisplayName("Home Phone Number")]
		[USPhoneNumber]
		//[Required]
		public string HomePhoneNumber
		{
			get { return _model.HomePhone; }
			set { _model.HomePhone = value; }
		}
		/// <summary>
		/// When adding someone, this represents the phone number contact record.
		/// </summary>
		[Display(Name = "Cell Phone Number")]
		[DisplayName("Cell Phone Number")]
		[USPhoneNumber]
		//[Required]
		public string CellPhoneNumber
		{
			get { return _model.PersonalCell; }
			set { _model.PersonalCell = value; }
		}
		/// <summary>
		/// When adding someone, this represents the email address contact record.
		/// </summary>
		[Display(Name = "Email Address")]
		[DisplayName("Email Address")]
		//[Required] -- Some parents dont have email addresses
		[UniqueEmailAddress(ErrorMessage = "The email address was already found in our system, please sign in or use another email.")]
		[Email(ErrorMessage = "The email address specified isn't an email address.")]
		public string EmailAddress
		{
			get { return _model.EmailAddress; }
			set { _model.EmailAddress = value; }
		}
		#endregion
		#endregion
		#region Logic
		public void SaveChanges()
		{
			_model.Person.ChangedTimeStamp = DateTime.Now;
			_model.Person.ChangedBy = -1;
			// If we have a valid home #, add it
			if (!string.IsNullOrWhiteSpace(HomePhoneNumber))
				_model.HomePhone = HomePhoneNumber;
			// If we have a valid cell #, add it
			if (!string.IsNullOrWhiteSpace(CellPhoneNumber))
				_model.PersonalCell = CellPhoneNumber;
			// If we have a valid email, add it
			if (!string.IsNullOrWhiteSpace(EmailAddress))
				_model.EmailAddress = EmailAddress;
			// Some fields may have 'not applicable'; blank them
			_model.Person.SpecialNeedsDescription = _model.Person.SpecialNeedsDescription.NormalizeNotApplicable().NullIfEmptyOrWhitespace();
			_model.Person.SpecialNeedsSummary = _model.Person.SpecialNeedsSummary.NormalizeNotApplicable().NullIfEmptyOrWhitespace();
			// Names of people should be proper case if they're all entered in lowercase
			_model.Person.FirstName = _model.Person.FirstName.NormalizeName();
			_model.Person.LastName = _model.Person.LastName.NormalizeName();
			if (PictureData != null && (PictureAction == "replace" || (PictureAction ?? "") == ""))
			{
				// Replace just adds, it does not remove the old picture.
				Photo pic = PhotoHandling.GetPhotoEntityFromBytes(PictureData);
				pic.ROWGUID = Guid.NewGuid();
				pic.OrganizationID = _model.AuthUser.OrganizationID;
				pic.CreationTimestamp = DateTime.Now;
				pic.Deleted = false;
				_model.AddNewPhoto(pic);
				_model.Person.Avatar = pic.ROWGUID;
			}
			else if (PictureAction == "remove" && _model.Person.Avatar.HasValue)
			{
				var pic = _model.Person.Photos.SingleOrDefault(p => p.ROWGUID == _model.Person.Avatar.Value);
				if (pic != null)
				{
					pic.Deleted = true;
					_model.Person.Avatar = null;
				}
			}
			_model.SaveChanges();
		}
		#endregion
	}
