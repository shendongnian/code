	public class EditFamilyMemberModel
	{
		public EditFamilyMemberModel() { }
		#region Properties
		[Required]
		[StringLength(100)]
		public string Address { get; set; }
		[StringLength(100)]
		public string Address2 { get; set; }
		[Required]
		[StringLength(50)]
		public string City { get; set; }
		[Required]
		[StringLength(50)]
		public string State { get; set; }
		[Required]
		[StringLength(50)]
		public string Zip { get; set; }
		[DataType(DataType.Date)]
		//[Required]
		public DateTime? DOB { get; set; }
		[Required]
		public string Gender { get; set; }
		[Required]
		public string FirstName { get; set; }
		[Required]
		public string LastName { get; set; }
		public int? SchoolID { get; set; }
		public int? GradeID { get; set; }
		public string SpecialNeedsDescription { get; set; }
		public string SpecialNeedsSummary { get; set; }
		public byte[] PictureData { get; set; }
		public string PictureAction { get; set; }
		
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
		public string HomePhoneNumber { get; set; }
		/// <summary>
		/// When adding someone, this represents the phone number contact record.
		/// </summary>
		[Display(Name = "Cell Phone Number")]
		[DisplayName("Cell Phone Number")]
		[USPhoneNumber]
		//[Required]
		public string CellPhoneNumber { get; set; }
		/// <summary>
		/// When adding someone, this represents the email address contact record.
		/// </summary>
		[Display(Name = "Email Address")]
		[DisplayName("Email Address")]
		//[Required] -- Some parents dont have email addresses
		//[UniqueEmailAddress(ErrorMessage = "The email address was already found in our system, please sign in or use another email.")]
		[Email(ErrorMessage = "The email address specified isn't an email address.")]
		public string EmailAddress { get; set; }
		#endregion
		#endregion
		#region Read-Only Properties
		public IList<School> Schools { get; internal set; }
		public IList<ContactType> ContactTypes { get; internal set; }
		public IList<string> Genders { get; internal set; }
		public IList<Grade> Grades { get; internal set; }
		public IList<USState> USStates { get; internal set; }
		public IList<PersonType> PersonTypes { get; internal set; }
		public IList<FamilyRole> FamilyRoles { get; internal set; }
		public Person Person { get; internal set; }
		#endregion
	}
	
	public class EditFamilyMemberService
	{
		
		#region Constructor
		public EditFamilyMemberService(ITracktionDataLayer dataLayer, MessagePasser messager, AuthUserHelper authUser, int originalPersonID, int familyMemberID)
		{
			_dataLayer = dataLayer;
			_originalPerson = new PersonAddEditModel(messager, dataLayer, authUser, originalPersonID);
			_model = new PersonAddEditModel(messager, dataLayer, authUser, familyMemberID);
			_grades = _dataLayer.GetGradesForOrganization(authUser.OrganizationID, _model.Person.Grade, true).ToArray();
			Model = new EditFamilyMemberModel()
			{
				Address = _model.Person.Address,
				Address2 = _model.Person.Address2,
				CellPhoneNumber = _model.PersonalCell,
				City = _model.Person.City,
				ContactTypes = _model.ContactTypes,
				DOB = _model.Person.DOB,
				EmailAddress = _model.EmailAddress,
				FamilyRoles = _model.FamilyRoles,
				FirstName = _model.Person.FirstName,
				Gender = _model.Person.Gender,
				Genders = _model.Genders,
				GradeID = _model.Person.Grade,
				Grades = _model.Grades,
				HomePhoneNumber = _model.HomePhone,
				LastName = _model.Person.LastName,
				Password = null,
				PasswordConfirm = null,
				PersonTypes = _model.PersonTypes,
				PictureAction = null,
				PictureData = null,
				SchoolID = _model.Person.SchoolID,
				Schools = _model.Schools,
				SpecialNeedsDescription = _model.Person.SpecialNeedsDescription,
				SpecialNeedsSummary = _model.Person.SpecialNeedsSummary,
				State = _model.Person.State,
				Username = null,
				USStates = _model.USStates,
				Zip = _model.Person.Zip,
				Person = _model.Person
			};
		}
		#endregion
		#region Private
		ITracktionDataLayer _dataLayer;
		PersonAddEditModel _originalPerson;
		PersonAddEditModel _model;
		IList<Grade> _grades;
		#endregion
		#region Properties
		public EditFamilyMemberModel Model { get; internal set; }
		#region Read Only
		public Person Person
		{
			get { return _model.Person; }
		}
		public AuthUserHelper AuthUser
		{
			get { return _model.AuthUser; }
		}
		#endregion
		#endregion
		#region Logic
		public void SaveChanges()
		{
			_model.Person.ChangedTimeStamp = DateTime.Now;
			_model.Person.ChangedBy = -1;
			// If we have a valid home #, add it
			if (!string.IsNullOrWhiteSpace(Model.HomePhoneNumber))
				_model.HomePhone = Model.HomePhoneNumber;
			// If we have a valid cell #, add it
			if (!string.IsNullOrWhiteSpace(Model.CellPhoneNumber))
				_model.PersonalCell = Model.CellPhoneNumber;
			// If we have a valid email, add it
			if (!string.IsNullOrWhiteSpace(Model.EmailAddress))
				_model.EmailAddress = Model.EmailAddress;
			// Some fields may have 'not applicable'; blank them
			Model.SpecialNeedsDescription = Model.SpecialNeedsDescription.NormalizeNotApplicable().NullIfEmptyOrWhitespace();
			Model.SpecialNeedsSummary = Model.SpecialNeedsSummary.NormalizeNotApplicable().NullIfEmptyOrWhitespace();
			// Names of people should be proper case if they're all entered in lowercase
			Model.FirstName = Model.FirstName.NormalizeName();
			Model.LastName = Model.LastName.NormalizeName();
			// Save this extra information
			_model.Person.Address = Model.Address;
			_model.Person.Address2 = Model.Address2;
			_model.PersonalCell = Model.CellPhoneNumber;
			_model.Person.City = Model.City;
			_model.Person.DOB = Model.DOB;
			_model.EmailAddress = Model.EmailAddress;
			_model.Person.FirstName = Model.FirstName;
			_model.Person.Gender = Model.Gender;
			_model.Person.Grade = Model.GradeID;
			_model.HomePhone = Model.HomePhoneNumber;
			_model.Person.LastName = Model.LastName;
			_model.Person.SchoolID = Model.SchoolID;
			_model.Person.SpecialNeedsDescription = Model.SpecialNeedsDescription;
			_model.Person.SpecialNeedsSummary = Model.SpecialNeedsSummary;
			_model.Person.State = Model.State;
			_model.Person.Zip = Model.Zip;
			// Save picture data
			if (Model.PictureData != null && (Model.PictureAction == "replace" || (Model.PictureAction ?? "") == ""))
			{
				// Replace just adds, it does not remove the old picture.
				Photo pic = PhotoHandling.GetPhotoEntityFromBytes(Model.PictureData);
				pic.ROWGUID = Guid.NewGuid();
				pic.OrganizationID = _model.AuthUser.OrganizationID;
				pic.CreationTimestamp = DateTime.Now;
				pic.Deleted = false;
				_model.AddNewPhoto(pic);
				_model.Person.Avatar = pic.ROWGUID;
			}
			else if (Model.PictureAction == "remove" && _model.Person.Avatar.HasValue)
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
