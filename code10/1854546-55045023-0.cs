namespace ESFA.DC.LARS.DTO
{
    public class CategoryDescDTO
    {
        public int CategoryRef { get; set; }
        public string CategoryName { get; set; }
    }
}
Then build the assembler:
public class CategoryDescAssembler {
    public CategoryDescDTO WriteDto(CategoryDesc categoryDesc) {
        var categoryDescDto = new CategoryDescDTO();
        categoryDescDto.CategoryRef = categoryDesc.CategoryRef;
        categoryDescDto.CategoryName = categoryDesc.CategoryName;
        return categoryDescDto;
    }
}
Now you implement the service to do all the work required to get the DTO object:
public class CategoryDescService {
    private readonly IRepository<CategoryDesc> _categoryDescRepository;
    private readonly CategoryDescAssembler _categoryDescAssembler;
    public CategoryDescService(IRepository<CategoryDesc> categoryDescRepository, CategoryDescAssembler categoryDescAssembler) {
        _categoryDescRepository= categoryDescRepository;
        _categoryDescAssembler= categoryDescAssembler;
    }
    public CategoryDescDTO GetCategoryDesc(int categoryRef) {
        var categDesc = _categoryDescRepository.Get(x => x.CategoryRef == categoryRef);
        return _categoryDescAssembler.WriteDto(categDesc);
    }
}
