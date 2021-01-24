    return connection.Query<Program,
    	AssistanceProgramCategory,
    	AssistanceProgramType,
    	AssistanceProgramLegalType,
    	ProgramAuthority,
    	Program>(sql: Constants.SqlStatements.SELECT_PROGRAMS_SQL,
    	(program, category, programType, legalType, authority) =>
    	{
    		program.AssistanceCategory = category;
    		program.ProgramType = programType;
    		program.ProgramLegalType = legalType;
    		program.Authority = authority;
    		return program;
    	}, splitOn: "Name,Jurisdiction");
