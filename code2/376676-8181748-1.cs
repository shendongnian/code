    class Base<TDTO> where TDTO : BaseDTO, new()
    {
        private string _name;
        public TDTO ToDTO()
        {
            TDTO dto = new TDTO();
            SetupDTO(dto);
            return dto;
        }
        protected virtual void SetupDTO(TDTO dto)
        {
            dto.Name = _name;
        }
    }
    class Inherited : Base<InheritedDTO>
    {
        private string _description;
        protected override void SetupDTO(TDTO dto)
        {
            base.SetupDTO(dto);
    
            dto.Description = _description;
        }
    }
